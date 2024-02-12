namespace Data_Layer.Custom_Models
{
    public interface IFormFile
    {
        string FileName { get; }

        void CopyTo(FileStream fileStream);
    }
}