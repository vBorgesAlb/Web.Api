namespace Web.Api.Dominio.Extensoes
{
    public static class ValidationResult
    {
        public static List<string> Erros(this FluentValidation.Results.ValidationResult validationResult)
        {
            var erros = new List<string>();
            foreach (var item in validationResult.Errors)
            {
                erros.Add(item.ErrorMessage);
            }

            return erros;
        }
    }
}
