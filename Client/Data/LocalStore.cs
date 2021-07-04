using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using PWA_Project.Shared;

namespace PWA_Project.Client.Data
{
    // To support offline use, we use this simple local data repository
    // instead of performing data access directly against the server.

    public class LocalStore
    {
        private readonly HttpClient httpClient;
        private readonly IJSRuntime js;
        private int count = 0;

        public LocalStore(HttpClient httpClient, IJSRuntime js)
        {
            this.httpClient = httpClient;
            this.js = js;
        }

        public ValueTask<Input[]> GetOutstandingLocalEditsAsyncInput()
        {
            return js.InvokeAsync<Input[]>("localStore.getAll", "localeditsInput");
        }

        public async Task SynchronizeAsync()
        {
            (await httpClient.GetAsync("api/course/getall")).EnsureSuccessStatusCode();

            foreach (var editedInput in await GetOutstandingLocalEditsAsyncInput())
            {
                if (count > 1)
                {
                    var tempId = editedInput.Id;

                    editedInput.Id = 0;
                    (await httpClient.PutAsJsonAsync("api/input/update", editedInput)).EnsureSuccessStatusCode();

                    editedInput.Id = tempId;
                    await DeleteAsync("localeditsInput", editedInput.Id);
                }

                count++;
            }

            await FetchChangesAsync();
        }

        public ValueTask SaveUserAccountAsync(ClaimsPrincipal user)
        {
            return user != null
                ? PutAsync("metadata", "userAccount", user.Claims.Select(c => new ClaimData { Type = c.Type, Value = c.Value }))
                : DeleteAsync("metadata", "userAccount");
        }

        public async Task<ClaimsPrincipal> LoadUserAccountAsync()
        {
            var storedClaims = await GetAsync<ClaimData[]>("metadata", "userAccount");
            return storedClaims != null
                ? new ClaimsPrincipal(new ClaimsIdentity(storedClaims.Select(c => new Claim(c.Type, c.Value)), "appAuth"))
                : new ClaimsPrincipal(new ClaimsIdentity());
        }

        public ValueTask<string[]> Autocomplete(string prefix)
            => js.InvokeAsync<string[]>("localStore.autocompleteKeys", "serverdataCourse", prefix, 5);

        // If there's an outstanding local edit, use that. If not, use the server data.
        public async Task<List<Course>> GetCoursesAll()
            => await GetAllAsync<List<Course>>("serverdataCourse")
            ?? await GetAllAsync<List<Course>>("serverdataCourse");

        public async Task<List<Input>> GetInputsAll()
            => await GetAllAsync<List<Input>>("localeditsInput")
            ?? await GetAllAsync<List<Input>>("serverdataInput");

        public async Task<List<Test>> GetTestsAll()
            => await GetAllAsync<List<Test>>("serverdataTest")
            ?? await GetAllAsync<List<Test>>("serverdataTest");

        public async Task<List<Question>> GetQuestionsAll()
            => await GetAllAsync<List<Question>>("serverdataQuestion")
            ?? await GetAllAsync<List<Question>>("serverdataQuestion");

        public async Task<List<Answer>> GetAnswersAll()
            => await GetAllAsync<List<Answer>>("serverdataAnswer")
            ?? await GetAllAsync<List<Answer>>("serverdataAnswer");

        public async ValueTask<DateTime?> GetLastUpdateDateAsync()
        {
            var value = await GetAsync<string>("metadata", "lastUpdateDate");
            return value == null ? (DateTime?)null : DateTime.Parse(value);
        }

        public ValueTask SaveInputAsync(Input input)
            => PutAsync("localeditsInput", null, input);

        async Task FetchChangesAsync()
        {
            var mostRecentlyUpdatedCourse = await js.InvokeAsync<Course>("localStore.getFirstFromIndex", "serverdataCourse", "id", "prev");
            var latest = mostRecentlyUpdatedCourse?.Id ?? 0;
            var json = await httpClient.GetStringAsync($"api/course/newdata?id={latest}");
            await js.InvokeVoidAsync("localStore.putAllFromJson", "serverdataCourse", json);
            await PutAsync("metadata", "lastUpdateDate", DateTime.Now.ToString("o"));

            var mostRecentlyUpdatedInput = await js.InvokeAsync<Input>("localStore.getFirstFromIndex", "serverdataInput", "id", "prev");
            latest = mostRecentlyUpdatedInput?.Id ?? 0;
            json = await httpClient.GetStringAsync($"api/input/newdata?id={latest}");
            await js.InvokeVoidAsync("localStore.putAllFromJson", "serverdataInput", json);
            await PutAsync("metadata", "lastUpdateDate", DateTime.Now.ToString("o"));

            var mostRecentlyUpdatedTest = await js.InvokeAsync<Test>("localStore.getFirstFromIndex", "serverdataTest", "id", "prev");
            latest = mostRecentlyUpdatedTest?.Id ?? 0;
            json = await httpClient.GetStringAsync($"api/test/newdata?id={latest}");
            await js.InvokeVoidAsync("localStore.putAllFromJson", "serverdataTest", json);
            await PutAsync("metadata", "lastUpdateDate", DateTime.Now.ToString("o"));

            var mostRecentlyUpdatedQuestion = await js.InvokeAsync<Question>("localStore.getFirstFromIndex", "serverdataQuestion", "id", "prev");
            latest = mostRecentlyUpdatedQuestion?.Id ?? 0;
            json = await httpClient.GetStringAsync($"api/question/newdata?id={latest}");
            await js.InvokeVoidAsync("localStore.putAllFromJson", "serverdataQuestion", json);
            await PutAsync("metadata", "lastUpdateDate", DateTime.Now.ToString("o"));

            var mostRecentlyUpdatedAnswer = await js.InvokeAsync<Answer>("localStore.getFirstFromIndex", "serverdataAnswer", "id", "prev");
            latest = mostRecentlyUpdatedAnswer?.Id ?? 0;
            json = await httpClient.GetStringAsync($"api/answer/newdata?id={latest}");
            await js.InvokeVoidAsync("localStore.putAllFromJson", "serverdataAnswer", json);
            await PutAsync("metadata", "lastUpdateDate", DateTime.Now.ToString("o"));
        }

        ValueTask<T> GetAsync<T>(string storeName, object key)
            => js.InvokeAsync<T>("localStore.get", storeName, key);

        ValueTask<T> GetAllAsync<T>(string storeName)
            => js.InvokeAsync<T>("localStore.getAll", storeName);

        ValueTask PutAsync<T>(string storeName, object key, T value)
            => js.InvokeVoidAsync("localStore.put", storeName, key, value);

        ValueTask DeleteAsync(string storeName, object key)
            => js.InvokeVoidAsync("localStore.delete", storeName, key);

        class ClaimData
        {
            public string Type { get; set; }
            public string Value { get; set; }
        }
    }
}
