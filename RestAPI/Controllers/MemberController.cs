using RestAPI.Models;
using RestAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RestAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Controllers
{
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
                var createdMember = await memberService.AddMember(member);

                return CreatedAtRoute("getmemberbyid", new { id = createdMember.Id }, createdMember);
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
                return NoContent();
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
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
