using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Naznean_LarisaGabriela_Proiect.Data;

namespace Naznean_LarisaGabriela_Proiect.Models
{
    public class AlbumCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Naznean_LarisaGabriela_ProiectContext context, Album Album)
        {
            var allCategories = context.Category;
            var AlbumCategories = new HashSet<int>(
            Album.AlbumCategories.Select(c => c.AlbumID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = AlbumCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateAlbumCategories(Naznean_LarisaGabriela_ProiectContext context,
 string[] selectedCategories, Album AlbumToUpdate)
        {
            if (selectedCategories == null)
            {
                AlbumToUpdate.AlbumCategories = new List<AlbumCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var AlbumCategories = new HashSet<int>
            (AlbumToUpdate.AlbumCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!AlbumCategories.Contains(cat.ID))
                    {
                        AlbumToUpdate.AlbumCategories.Add(
                        new AlbumCategory
                        {
                            AlbumID = AlbumToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (AlbumCategories.Contains(cat.ID))
                    {
                        AlbumCategory courseToRemove
                        = AlbumToUpdate
                        .AlbumCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
