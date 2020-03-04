using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace WebMarkReport.Models
{
    public static class SeedData
    {
        /// <summary>
        /// Заполнение базы данных
        /// </summary>
        /// <param name="app"></param>
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate(); //если база еще не существует, она будет создана
            if (!context.Structures.Any() || !context.Reports.Any())
            {
                XmlData.Deserialize();
                context.Structures.AddRange(XmlData.structures);
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Structures ON"); //отменить автоинкремент столбца id, иначе возникает ошибка. 
                                                                                                // Нужно для сохранения нумерации элементов в базе в соответствии с файлом xml 
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Structures OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
                context.Reports.AddRange(XmlData.reports);
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Reports ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Reports OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }
        }

    }
}
