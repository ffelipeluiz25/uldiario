namespace uldiario.Models.EntidadesApiLoterias
{
	public partial class ErrorResponse
	{
		public string Error { get; set; }
		public string StackTrace { get; set; }
		public Issues Issues { get; set; }
	}

	public partial class Issues
	{
		public string[] AdditionalProp1 { get; set; }
		public string[] AdditionalProp2 { get; set; }
		public string[] AdditionalProp3 { get; set; }
	}
}