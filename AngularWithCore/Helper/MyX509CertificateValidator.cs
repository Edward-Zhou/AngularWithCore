﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AngularWithCore.Helper
{
    public class MyX509CertificateValidator : X509CertificateValidator
    {
        string allowedIssuerName;

        public MyX509CertificateValidator(string allowedIssuerName)
        {
            if (allowedIssuerName == null)
            {
                throw new ArgumentNullException("allowedIssuerName");
            }

            this.allowedIssuerName = allowedIssuerName;
        }

        public override void Validate(X509Certificate2 certificate)
        {
            // Check that there is a certificate.
            if (certificate == null)
            {
                throw new ArgumentNullException("certificate");
            }

            // Check that the certificate issuer matches the configured issuer.
            if (allowedIssuerName != certificate.IssuerName.Name)
            {
            }
        }
    }
}
