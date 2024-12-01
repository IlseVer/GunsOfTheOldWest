using System.ComponentModel.DataAnnotations;

public class Player
{
	[Required(ErrorMessage = "Voornaam is verplicht.")]
	public required string FirstName { get; set; }

	[Required(ErrorMessage = "Familienaam is verplicht.")]
	public required string LastName { get; set; }

	[Required(ErrorMessage = "Emailadres is verplicht.")]
	[EmailAddress(ErrorMessage = "Voer een geldig emailadres in.")]
	public required string Email { get; set; }

	[Required(ErrorMessage = "Telefoonnummer is verplicht.")]
	[Phone(ErrorMessage = "Een telefoonnummer mag enkel cijfers bevatten")]
	public required string PhoneNumber { get; set; }

	public DateTime SubmissionDate { get; set; }
}

