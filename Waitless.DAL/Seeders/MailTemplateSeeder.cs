using Microsoft.EntityFrameworkCore;
using Waitless.DAL.Enums;
using Waitless.DAL.Models;

namespace Waitless.DAL.Seeders
{
    internal class MailTemplateSeeder
    {
        internal static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailTemplate>().HasData(new MailTemplate
            {
                Id = (int)MailTemplateEnum.Verify,
                Subject = "Waitless Mail Verification",
                HtmlBody = @"
                        <!DOCTYPE html>
                        <html>
                        <head>
                            <title>Waitless - Email Verification</title>
                        </head>
                        <body style=""font-family: Arial, sans-serif; line-height: 1.6;"">
                            <h2>Dear {FirstName},</h2>
                            <p>
                                Thank you for joining Waitless! To activate your account and access our services,
                                please verify your email address by clicking the link below:
                            </p>
                            <p style=""background-color: #f2f2f2; padding: 10px;"">
                                <a href=""{verificationLink}"" target=""_blank"" style=""color: #007BFF; text-decoration: none;"">
                                    {verificationLink}
                                </a>
                            </p>
                            <p>
                                If you did not sign up for Waitless, please ignore this email.
                            </p>
                            <p>Best regards,</p>
                            <p>Waitless team</p>
                        </body>
                        </html>
                        ",
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });

            modelBuilder.Entity<MailTemplate>().HasData(new MailTemplate
            {
                Id = (int)MailTemplateEnum.Reset,
                Subject = "Waitless Reset Password",
                HtmlBody = @"
                        <!DOCTYPE html>
                        <html>
                        <head>
                            <title>Waitless - Password Reset</title>
                        </head>
                        <body style=""font-family: Arial, sans-serif; line-height: 1.6;"">
                            <h2>Dear {FirstName},</h2>
                            <p>
                                We received a request to reset your password for your Waitless account. 
                                If you didn't initiate this request, you can ignore this email.
                            </p>
                            <p>
                                To reset your password, click on the link below:
                            </p>
                            <p style=""background-color: #f2f2f2; padding: 10px;"">
                                <a href=""{resetLink}"" target=""_blank"" style=""color: #007BFF; text-decoration: none;"">
                                    Reset Password
                                </a>
                            </p>
                            <p>
                                If the above link doesn't work, you can copy and paste the following URL 
                                into your web browser's address bar:
                            </p>
                            <p>
                                This password reset link will expire in 24 hour.
                            </p>
                            <p>
                                If you didn't request a password reset, no action is required on your part.
                            </p>
                            <p>Best regards,</p>
                            <p>Waitless team</p>
                        </body>
                        </html>
                        ",
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });

        }
    }
}
