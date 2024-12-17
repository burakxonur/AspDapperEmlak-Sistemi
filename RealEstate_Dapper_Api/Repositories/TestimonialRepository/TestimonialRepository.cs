using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
	public class TestimonialRepository:ITestimonialRepository
	{
		private readonly Context _context;

		public TestimonialRepository(Context context)
		{
			_context = context;
		}

		public async void CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			string query = "Insert into Testimonial(TestimonialID,NameSurname,Title,Comment,Status) values (@nameSurname,@title,@comment,@status)";
			var parameters = new DynamicParameters();
			parameters.Add("@nameSurname", createTestimonialDto.NameSurname);
			parameters.Add("@title", createTestimonialDto.Title);
			parameters.Add("@comment", createTestimonialDto.Comment);
			parameters.Add("@status", createTestimonialDto.Status);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async void DeleteTestimonial(int id)
		{
			string query = "Delete from Testimonial where TestimonialID=@Testimonialid";
			var parameters = new DynamicParameters();
			parameters.Add("Testimonialid", id);
			using(var connection =_context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
		{
			string query = "Select * from Testimonial";
			using (var conntection = _context.CreateConnection())
			{
				var values = await conntection.QueryAsync<ResultTestimonialDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIDTestimonial> GetTestimonial(int id)
		{
			string query = "Select * From Testimonial where TestimonialID=@TestimonialiD";
			var parameters = new DynamicParameters();
			parameters.Add("@TestimonialiD", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIDTestimonial>(query, parameters);
				return values;
			}
		}

		public async void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			string query = "Update Testimonial Set NameSurname=@nameSurname,Title=@title,Comment=@comment,Status=@status where TestimonialID=@TestimonialiD";
			var parameters = new DynamicParameters();
			parameters.Add("@TestimonialiD", updateTestimonialDto.NameSurname);
			parameters.Add("@title", updateTestimonialDto.Title);
			parameters.Add("@comment", updateTestimonialDto.Comment);
			parameters.Add("@status", updateTestimonialDto.Status);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
