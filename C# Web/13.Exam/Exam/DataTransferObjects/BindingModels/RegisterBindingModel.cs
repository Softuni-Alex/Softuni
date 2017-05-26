namespace DataTransferObjects.BindingModels
{
    public class RegisterBindingModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
