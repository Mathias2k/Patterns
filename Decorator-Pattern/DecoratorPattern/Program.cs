namespace DecoratorPattern
{
   public class Program
   {
      static void Main()
      {
         new CallMethods(new FileService())
               .MethodsDecoratorPatterns(nomeDocumento: "documento_teste");
      }
   }
   public class CallMethods
   {
      private IFileService _fileService;
      public CallMethods(IFileService fileService)
      {
         _fileService = fileService;
      }
      public void MethodsDecoratorPatterns(string nomeDocumento)
      {
         Console.WriteLine("Documento Original: " + nomeDocumento);

         _fileService = new RenameFileService(_fileService);
         _fileService = new ResizeFileService(_fileService);
         _fileService = new ChangeExtensionFileService(_fileService);
         _fileService.SaveFile(nomeDocumento);
      }
   }

   //base
   public class FileService : IFileService
   {
      public void SaveFile(string nomeArquivo)
      {
         Console.WriteLine("Saved: " + nomeArquivo);
      }
   }
   public interface IFileService
   {
      void SaveFile(string nomeArquivo);
   }
   public class RenameFileService : IFileService
   {
      private readonly IFileService _fileService;
      public RenameFileService(IFileService fileService)
      {
         _fileService = fileService;
      }
      public void SaveFile(string nomeArquivo)
      {
         var renamedFile = RenameFile(nomeArquivo);
         _fileService.SaveFile(renamedFile);
      }
      private string RenameFile(string nomeArquivo)
      {
         string renamedFile = nomeArquivo + " - renamed";
         Console.WriteLine(renamedFile);

         return renamedFile;
      }
   }
   public class ChangeExtensionFileService : IFileService
   {
      private readonly IFileService _fileService;
      public ChangeExtensionFileService(IFileService fileService)
      {
         _fileService = fileService;
      }
      public void SaveFile(string nomeArquivo)
      {
         var renamedFile = ChangeExtensionFile(nomeArquivo);
         _fileService.SaveFile(renamedFile);
      }
      private string ChangeExtensionFile(string nomeArquivo)
      {
         string changedExtensions = nomeArquivo + " - extension changed";
         Console.WriteLine(changedExtensions);

         return changedExtensions;
      }
   }
   public class ResizeFileService : IFileService
   {
      private readonly IFileService _fileService;
      public ResizeFileService(IFileService fileService)
      {
         _fileService = fileService;
      }
      public void SaveFile(string nomeArquivo)
      {
         var renamedFile = ResizeFile(nomeArquivo);
         _fileService.SaveFile(renamedFile);
      }
      private string ResizeFile(string nomeArquivo)
      {
         string resizedFile = nomeArquivo + " - resized 50%";
         Console.WriteLine(resizedFile);

         return resizedFile;
      }
   }
}