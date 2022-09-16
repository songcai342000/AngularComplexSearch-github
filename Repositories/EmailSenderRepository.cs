using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using System.Linq;
using System.Threading.Tasks;
using AngularComplexSearch.Models;

namespace AngularComplexSearch.Models
.Repositories
{
    public class EmailSenderRepository: IEmailSender
    {
		public async Task SendEmailAsync(string email, string subject, string message)
		{
			var mimeEmail = new MimeMessage();
			mimeEmail.Subject = subject;
			mimeEmail.From.Add(new MailboxAddress("Real Time Position", "songcai342000@gmail.com"));
			mimeEmail.To.Add(new MailboxAddress("User", email));

			mimeEmail.Body = new TextPart("html")
			{
				Text = message
			};

			using (var client = new SmtpClient())
			{
				client.ServerCertificateValidationCallback = (sender, certificate, certChainType, errors) => true;
				client.AuthenticationMechanisms.Remove("XOAUTH2");
				await client.ConnectAsync("smtp.gmail.com", 587);
				await client.AuthenticateAsync("songcai342000@gmail.com", "mcnixnpdfytcksoy");
				await client.SendAsync(mimeEmail);
				await client.DisconnectAsync(true);
			}
		}
		
	}
}
