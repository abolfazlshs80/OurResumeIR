using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;
using OurResumeIR.Application.ViewModels.MySkills;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;

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

    public async Task<SkillLevelVM> GetById(int Id)
    {
        var rep_SkillLevel = unitOfWork.SkillLevelRepository;
        return mapper.Map<SkillLevelVM>((await rep_SkillLevel.FindAsync(a => a.Id == Id)).FirstOrDefault());
    }

    public async Task<bool> Update(UpdateSkillLevelVM model)
    {
        var rep_SkillLevel = unitOfWork.SkillLevelRepository;
        var newModel = new SkillLevel()
        {
            Id = model.Id,
            Name = model.Name,
            Percentage = model.Percentage
        };
        bool status = await rep_SkillLevel.UpdateSkillLevelLevel(newModel);
        await rep_SkillLevel.SaveChanges();

        return status;
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

    public async Task<bool> Delete(int Id)
    {
        var rep_SkillLevel = unitOfWork.SkillLevelRepository;
        var status = await rep_SkillLevel.DeleteSkillLevelLevel(Id);
        await rep_SkillLevel.SaveChanges();
        return status;

    }








}