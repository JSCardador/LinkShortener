using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class LinkController : ControllerBase
{
    private readonly IConnectionMultiplexer _redis;

    public LinkController(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    [HttpPost]
    public async Task<IActionResult> CreateShortLink([FromBody] Link link)
    {
        if (string.IsNullOrEmpty(link.OriginalUrl))
            return BadRequest("OriginalUrl is required");

        var db = _redis.GetDatabase();

        // Generar un identificador corto único
        link.ShortUrl = Guid.NewGuid().ToString().Substring(0, 8);

        await db.StringSetAsync(link.ShortUrl, link.OriginalUrl);

        // Construir la URL completa (https://localhost:5001/Link/{shortUrl})
        var shortUrl = $"{Request.Scheme}://{Request.Host}/Link/{link.ShortUrl}";

        return Ok(new { originalUrl = link.OriginalUrl, shortUrl });
    }


    [HttpGet("{shortUrl}")]
    public async Task<IActionResult> GetOriginalLink(string shortUrl)
    {
        Console.WriteLine("Buscando URL original para el short URL: " + shortUrl);

        var db = _redis.GetDatabase();

        var originalUrl = await db.StringGetAsync(shortUrl);

        if (originalUrl.IsNullOrEmpty)
            return NotFound("El enlace acortado no existe");

        return Redirect(originalUrl);
    }
}