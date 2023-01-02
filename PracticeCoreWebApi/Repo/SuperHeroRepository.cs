using Microsoft.EntityFrameworkCore;
using PracticeCoreWebApi.Data;
using PracticeCoreWebApi.Model;

namespace PracticeCoreWebApi.Repo
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly DataContext _context;
        public SuperHeroRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<SuperHeroResponseModel> GetAllSuperHeroDetail()
        {
            try
            {
                SuperHeroResponseModel objResponse = new SuperHeroResponseModel();
                var lstsuperhero = await _context.SuperHeros.ToListAsync();
                if (!lstsuperhero.Any())
                {
                    objResponse.CommonResponseStatus.Status = true;
                    objResponse.CommonResponseStatus.Message = "There is no superhero detail";
                }
                else
                {
                    objResponse.CommonResponseStatus.Status = true;
                    objResponse.CommonResponseStatus.Message = "Success";
                    objResponse.lstSuperHero = lstsuperhero;
                }
                return objResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SuperHeroResponseModel> GetSuperHeroById(int id)
        {
            try
            {
                SuperHeroResponseModel objResponse = new SuperHeroResponseModel();
                var superhero = await _context.SuperHeros.FirstOrDefaultAsync(x => x.Id == id);
                if (superhero != null)
                {
                    objResponse.CommonResponseStatus.Status = true;
                    objResponse.CommonResponseStatus.Message = "Success";
                    objResponse.SuperHero = superhero;
                }
                else
                {
                    objResponse.CommonResponseStatus.Status = true;
                    objResponse.CommonResponseStatus.Message = "There is no superhero detail";
                }
                return objResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CommonResponseStatus> AddSuperHeroDetail(SuperHero newSuperHero)
        {
            try
            {
                CommonResponseStatus obj = new CommonResponseStatus();
                var addresult = await _context.SuperHeros.AddAsync(newSuperHero);
                if(addresult != null)
                {
                    var a= await _context.SaveChangesAsync();
                    if(a>0)
                    {
                        obj.Message = "SuperHero Record Added Successfully !";
                        obj.Status = true;
                        return obj;
                    }
                    else
                    {
                        obj.Message = "Failed to Add Data!";
                        obj.Status = false;
                        return obj;
                    }
                }
                else
                {
                    return obj;
                }                 
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CommonResponseStatus> UpdateSuperHeroDetail(SuperHero newSuperHero)
        {
            try
            {
                CommonResponseStatus obj = new CommonResponseStatus();
                var superhero = await _context.SuperHeros.Where(x => x.Id == newSuperHero.Id).FirstOrDefaultAsync();
                if(superhero != null)
                {
                    superhero.Name = newSuperHero.Name;
                    superhero.SpecialPower = newSuperHero.SpecialPower;
                    superhero.NickName = newSuperHero.NickName;
                    superhero.HisMovieName = newSuperHero.HisMovieName;
                    _context.Entry(superhero).State=EntityState.Modified;
                    var result = _context.SaveChanges();                                    
                    if (result > 0)
                     {
                         obj.Message = "SuperHero Record Updated Successfully !";
                         obj.Status = true;
                         return obj;
                     }
                     else
                     {
                        obj.Message = "Failed to Update Data!";
                        obj.Status = false;
                        return obj;
                     }                   
                }                          
                else
                {
                    obj.Message = "Invalid SuperHero !";
                    obj.Status = false;
                    return obj;                  
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CommonResponseStatus> DeleteSuperHero(int id)
        {
            try
            {
                CommonResponseStatus obj = new CommonResponseStatus();
                var superhero = await _context.SuperHeros.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (superhero != null)
                {
                    _context.SuperHeros.Remove(superhero);
                    var result = _context.SaveChanges();
                    if (result > 0)
                    {
                        obj.Message = "SuperHero Record Deleted Successfully !";
                        obj.Status = true;
                        return obj;
                    }
                    else
                    {
                        obj.Message = "Failed to Delete Data!";
                        obj.Status = false;
                        return obj;
                    }
                }
                else
                {
                    obj.Message = "Invalid SuperHero !";
                    obj.Status = false;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
