using Azure.Storage.Blobs;

string connectionString = "UseDevelopmentStorage=true";
string containerName = "sample-container";
string blobName = "sample-blob.txt";
        
BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
BlobClient blobClient = containerClient.GetBlobClient(blobName);

var response = await blobClient.DownloadAsync();
using var streamReader = new StreamReader(response.Value.Content);
string content = await streamReader.ReadToEndAsync();
Console.WriteLine(content);