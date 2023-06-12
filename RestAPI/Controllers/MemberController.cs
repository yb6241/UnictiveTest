using RestAPI.Models;
using RestAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RestAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace RestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService memberService;

        public MemberController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        [HttpGet("getmemberlist")]
        public async Task<IActionResult> GetMember()
        {
            try
            {
                var members = await memberService.GetMember();
                return Ok(members);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{Id}", Name = "getmemberbyid")]
        public async Task<IActionResult> GetMemberById(int Id)
        {
            try
            {
                var member = await memberService.GetMemberById(Id);
                if (member == null)
                    return NotFound();
                return Ok(member);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(Member member)
        {
            try
            {
                //cek email
                var cekEmail = await memberService.GetMemberByEmail(member.Email);
                if(cekEmail != null && cekEmail.Email.Count() > 1)
                {
                    return BadRequest("Email '" + member.Email + "' sudah terdaftar.");
                }
                else
                {
                    await memberService.AddMember(member);
                    await memberService.AddNewHobby(member.Hobby);

                    return CreatedAtRoute("getmemberbyid", new { id = member.Id }, member);
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateMember(int Id, Member member)
        {
            try
            {
                var dbMember = await memberService.GetMemberById(Id);
                if (dbMember == null)
                    return NotFound();
                await memberService.UpdateMember(Id, member);
                await memberService.UpdateHobby(member.Hobby);
                return CreatedAtRoute("getmemberbyid", new { id = Id }, member);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMember(int Id)
        {
            try
            {
                var dbMember = await memberService.GetMemberById(Id);
                if (dbMember == null)
                    return NotFound();
                await memberService.DeleteMember(Id);
                return StatusCode(200, true);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
