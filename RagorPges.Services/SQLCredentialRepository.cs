using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPages.Services
{
    public class SQLCredentialRepository : ICredentialRepository
    {
        private readonly AppDbContext context;

        public SQLCredentialRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Credential Add(Credential newCredential)
        {  
            context.Credentials.Add(newCredential);
            context.SaveChanges();
            return newCredential;
        }
    }
}
