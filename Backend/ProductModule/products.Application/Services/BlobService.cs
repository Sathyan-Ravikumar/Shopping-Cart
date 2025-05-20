using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using products.Application.Services_Interface;
using Microsoft.AspNetCore.Http;


namespace products.Application.Services
{
    public class BlobService : IBlobService
    {
        private readonly IConfiguration _config;

        public BlobService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            var blobServiceClient = new BlobServiceClient(_config["StorageAccount:ConnectionString"]);
            var containerClient = blobServiceClient.GetBlobContainerClient(_config["StorageAccount:ContainerName"]);
            await containerClient.CreateIfNotExistsAsync();
            var blobClient = containerClient.GetBlobClient(Guid.NewGuid() + Path.GetExtension(file.FileName));

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }

            return blobClient.Uri.ToString();
        }
    }
}
