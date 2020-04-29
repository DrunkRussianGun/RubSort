using IdentitySystem;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private AuthenticationManager _authenticationManager;

        public AuthenticationController(AuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        // GET
        public void Register()
        {
            
        }
        
        public void Login()
        {
            
        }
        
        public void Logout()
        {
            
        }
        
        public void ForgotPassword()
        {
            
        }
        
        public void ResetPassword()
        {
            
        }
    }
}