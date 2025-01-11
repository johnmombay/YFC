using Web.YFC.Common;
using Web.YFC.Models;
using System.Text.Json;

namespace Web.YFC.Services
{
	public class StatementServices
	{
		public async Task<List<Statement>> GetStatements()
		{
			List<Statement> contacts = new List<Statement>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.StatementEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Statement>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Statement> GetStatementById(int id)
		{
			Statement Statement = new Statement();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.StatementEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Statement = JsonSerializer.Deserialize<Statement>(result, AppSettings.options)!;
			}
			return Statement;
		}

		public async Task<Statement> AddStatement(Statement Statement)
		{
			Statement StatementDb = new Statement();

			var data = JsonSerializer.Serialize(Statement).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.StatementEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				StatementDb = JsonSerializer.Deserialize<Statement>(result, AppSettings.options)!;
				return StatementDb;
			}
			return Statement;
		}

		public async Task<Statement> UpdateStatement(Statement Statement)
		{
			Statement StatementDb = new Statement();
			var data = JsonSerializer.Serialize(Statement).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.StatementEndpoint + "/" + Statement.StatementId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.StatementEndpoint + "/" + Statement.StatementId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				StatementDb = JsonSerializer.Deserialize<Statement>(result, AppSettings.options)!;
				return StatementDb;
			}
			return Statement;
		}

		public async Task<string> DeleteStatement(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.StatementEndpoint + "/" + id);
			return result;
		}
	}
}
