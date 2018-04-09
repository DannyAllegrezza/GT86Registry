namespace GT86Registry.Web.Models.ManageViewModels
{
    public class TwoFactorAuthenticationViewModel
    {
        public bool HasAuthenticator { get; set; }

        public bool Is2faEnabled { get; set; }
        public int RecoveryCodesLeft { get; set; }
    }
}