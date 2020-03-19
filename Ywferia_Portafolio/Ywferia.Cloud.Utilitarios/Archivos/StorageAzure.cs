using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;


namespace Ywferia.Cloud.Utilitarios.Archivos
{
    public static class StorageAzure
    {
        public static IEnumerable<string> ObtieneParametros(string ruta)
        {
            var lista = ruta.Split('\\');

            if (lista.Count() == 1)
                lista = ruta.Split('/');

            return lista;
        }
        public static void SubirArchivo(Stream archivo, string carpeta, string nombre,string conexionST)
        {
            var storageAccount = CloudStorageAccount.Parse(conexionST);
            // Create the blob client.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            var container = blobClient.GetContainerReference(carpeta.Trim().ToLower());

            // Create the container if it doesn't already exist.
            container.CreateIfNotExistsAsync();

            container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            // Retrieve reference to a blob named "myblob".
            var blockBlob = container.GetBlockBlobReference(nombre.Trim());

            // Create or overwrite the "myblob" blob with contents from a local file.            
            blockBlob.UploadFromStreamAsync(archivo);
        }
        //public static Dictionary<string, string> ListarArchivo(string carpeta,string conexionST)
        //{
        //    // Retrieve storage account from connection string.
        //    var storageAccount = CloudStorageAccount.Parse(conexionST);

        //    // Create the blob client.
        //    var blobClient = storageAccount.CreateCloudBlobClient();

        //    // Retrieve reference to a previously created container.
        //    var container = blobClient.GetContainerReference(carpeta.Trim().ToLower());

        //    return container.getb().Result<BlobResultSegment>().ToDictionary(blob => string.Format("{0}\\{1}", carpeta.ToLower(), blob.Name), blob => blob.Name);
        //}
        //public static IEnumerable<string> ListarArchivoDetalle(string ruta,string conexionST)
        //{
        //    // Retrieve storage account from connection string.
        //    var storageAccount = CloudStorageAccount.Parse(conexionST);

        //    // Create the blob client.
        //    var blobClient = storageAccount.CreateCloudBlobClient();

        //    // Retrieve reference to a previously created container.
        //    var container = blobClient.GetContainerReference(ruta.Trim().ToLower());

        //    return container.ListBlobsSegmentedAsync().OfType<CloudBlockBlob>().Select(file => string.Format("{0},{1},{2},{3},{4}", file.Name, string.Format("{0}\\{1}", ruta.ToLower(), file.Name), string.Empty, file.Properties.LastModified, file.Properties.Length)).ToList();
        //}
        public static byte[] LeerArchivo(string carpeta, string nombre,string conexionST)
        {
            var conexion = conexionST;
            // Retrieve storage account from connection string.
            var storageAccount = CloudStorageAccount.Parse(conexion);

            // Create the blob client.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            var container = blobClient.GetContainerReference(carpeta.Trim().ToLower());

            // Retrieve reference to a blob named "photo1.jpg".
            var blockBlob = container.GetBlockBlobReference(nombre.Trim());

            // Save blob contents to a file.
            var fileStream = new MemoryStream();
            blockBlob.DownloadToStreamAsync(fileStream);
            return fileStream.ToArray();
        }

        public static MemoryStream LeeArchivo(string carpeta, string nombre,string conexionST)
        {
            var conexion = conexionST;
            // Retrieve storage account from connection string.
            var storageAccount = CloudStorageAccount.Parse(conexion);

            // Create the blob client.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            var container = blobClient.GetContainerReference(carpeta.Trim().ToLower());

            // Retrieve reference to a blob named "photo1.jpg".
            var blockBlob = container.GetBlockBlobReference(nombre.Trim());

            // Save blob contents to a file.
            var fileStream = new MemoryStream();
            blockBlob.DownloadToStreamAsync(fileStream);
            return fileStream;
        }

        public static bool VerificaArchivo(string carpeta, string nombre,string conexionST)
        {
            // Retrieve storage account from connection string.
            var storageAccount = CloudStorageAccount.Parse(conexionST);

            // Create the blob client.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            var container = blobClient.GetContainerReference(carpeta.Trim().ToLower());

            // Retrieve reference to a blob named "photo1.jpg".
            var blockBlob = container.GetBlockBlobReference(nombre.Trim());

            // Save blob contents to a file.            
            return blockBlob != null;
        }
        public static bool EliminarArchivo(string carpeta, string nombre,string conexionST)
        {
            bool resultado;
            // Retrieve storage account from connection string.
            var storageAccount = CloudStorageAccount.Parse(conexionST);

            // Create the blob client.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            var container = blobClient.GetContainerReference(carpeta.Trim().ToLower());

            // Retrieve reference to a blob named "myblob.txt".
            var blockBlob = container.GetBlockBlobReference(nombre.Trim());

            try
            {
                // Delete the blob.
                blockBlob.DeleteAsync();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        public static void CrearArchivo(IEnumerable<string> detalle, string ruta, string nombre,string conexionST)
        {
            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);
            detalle.ToList().ForEach(streamWriter.WriteLine);
            streamWriter.Flush();

            stream.Position = 0;
            var arreglo = stream.ToArray();
            SubirArchivo(new MemoryStream(arreglo), ruta, nombre, conexionST);
        }
    }
}
