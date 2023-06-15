using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;

namespace Services.Signature
{
    public class SignatureService : ISignatureService
    {
        public SignatureService()
        {

        }
        public string GetSignature(string certificatePathPfx, string certificatePassPfx, string dataToSign)
        {
            try
            {
                var certificatePfx = new X509Certificate2(certificatePathPfx, certificatePassPfx);

                using (RSA rsa = certificatePfx.GetRSAPrivateKey())
                {
                    var signedData = rsa.SignData(Encoding.UTF8.GetBytes(dataToSign), HashAlgorithmName.SHA512, RSASignaturePadding.Pss);

                    return Convert.ToBase64String(signedData);
                }

            }
            catch (Exception e)
            {
                throw new ArgumentException("The data was not signed. \n Certificate path:" + certificatePathPfx + '\n' + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
