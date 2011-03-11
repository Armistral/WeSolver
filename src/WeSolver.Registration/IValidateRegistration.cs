namespace WeSolver.Registration
{
    public interface IValidateRegistration
    {
        SignedUser TryValidate(IRegistrationSettings settings, string providerSignedRequest);
    }
}
