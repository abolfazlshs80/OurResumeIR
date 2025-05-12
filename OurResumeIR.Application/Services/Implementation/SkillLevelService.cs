using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;
using OurResumeIR.Application.ViewModels.MySkills;
using OurResumeIR.Application.ViewModels.SkillLevel;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using System.Xml.Linq;

namespace OurResumeIR.Application.Services.Interfaces;

public class SkillLevelService(IUnitOfWork unitOfWork, IMapper mapper) : ISkillLevelService
{

    public async Task<List<SkillLevelVM>> GetAll()
    {
        var rep_SkillLevel = unitOfWork.SkillLevelRepository;
        try
        {
            var list = (await rep_SkillLevel.FindAsync(a => a.Id != 0)).ToList();
            return mapper.Map<List<SkillLevelVM>>(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    public async Task<List<SkillLevelVM>> GetAll(string userId)
    {
        return mapper.Map <List<SkillLevelVM>>( await unitOfWork.SkillLevelRepository.GetAllSkillLevelAsync(userId));
    }

    public async Task<SkillLevelVM> GetById(int Id)
    {
        var rep_SkillLevel = unitOfWork.SkillLevelRepository;
        return mapper.Map<SkillLevelVM>((await rep_SkillLevel.FindAsync(a => a.Id == Id)).FirstOrDefault());
    }

    public async Task<bool> Update(UpdateSkillLevelVM model)
    {
        var rep_SkillLevel = unitOfWork.SkillLevelRepository;
     
        var skillLevel = await rep_SkillLevel.GetSkillLevelById(model.Id);
        if (skillLevel == null | !skillLevel.UserId.Equals(model.UserId))
            return false;
        //bool status = await rep_SkillLevel.UpdateSkillLevelLevel(newModel);
        skillLevel.Name = model.Name;
        skillLevel.Percentage = model.Percentage;
        await rep_SkillLevel.SaveChanges();

        return true;
    }

    public async Task<bool> Create(CreateSkillLevelVM model)
    {
        
        var rep_SkillLevel = unitOfWork.SkillLevelRepository;
        var newModel = mapper.Map<SkillLevel>(model);
        int id = await rep_SkillLevel.CreateSkillLevelLevel(newModel);
        await rep_SkillLevel.SaveChanges();
        if (newModel.Id != 0)
            return true;

        return false;

    }


    public async Task<bool> Delete(int Id,string userId)
    {
        var rep_SkillLevel = unitOfWork.SkillLevelRepository;
        var skillLevel =await rep_SkillLevel.GetSkillLevelById(Id);
        if (skillLevel == null | !skillLevel.UserId.Equals(userId))
            return false;
        var status = await rep_SkillLevel.DeleteSkillLevelLevel(Id);
        await rep_SkillLevel.SaveChanges();
        return status;

    }








}