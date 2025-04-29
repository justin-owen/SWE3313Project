using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Luckys_Cars.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.JSInterop;



    public class Authenticator : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IJSRuntime _jsRuntime;
        private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

        public Authenticator(ILocalStorageService localStorage, IJSRuntime jsRuntime)
        {
            _localStorage = localStorage;
            _jsRuntime = jsRuntime;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var isJsAvailable = await _jsRuntime.InvokeAsync<bool>("eval", "typeof window !== 'undefined'");

                if (!isJsAvailable)
                {
                    // Still prerendering: return unauthenticated user
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
            }
            catch
            {
                // JS is unavailable because of prerendering
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            // Now JS is available, safe to access LocalStorage
            var userId = await _localStorage.GetItemAsync<int?>("userId");

            if (userId != null)
            {
                var userName = await _localStorage.GetItemAsync<string>("userName");
                var isAdmin = await _localStorage.GetItemAsync<int>("isAdmin");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userName ?? ""),
                    new Claim(ClaimTypes.NameIdentifier, userId.Value.ToString()),
                    new Claim("IsAdmin", isAdmin.ToString())
                };

                _currentUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));
            }
            else
            {
                _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            }

            return new AuthenticationState(_currentUser);
        }



        public async Task SignInAsync(User_Model user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim("IsAdmin", user.IsAdmin.ToString())
            };

            _currentUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));

            await _localStorage.SetItemAsync("userId", user.UserId);
            await _localStorage.SetItemAsync("userName", user.Name);
            await _localStorage.SetItemAsync("isAdmin", user.IsAdmin);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public Task SignOutAsync()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return Task.CompletedTask;
        }

    }
