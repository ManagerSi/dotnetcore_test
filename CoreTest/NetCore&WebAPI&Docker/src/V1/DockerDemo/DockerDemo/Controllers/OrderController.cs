using DockerDemo.Model;
using Microsoft.AspNetCore.Mvc;

namespace DockerDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        // ���������ҵ���߼�ʵ�ֶ�����صĽӿ�

        // ʾ������ȡ�����б�
        [HttpGet]
        public IActionResult GetOrders()
        {
            // �ڴ˴���Ӵ����Է��ض�������

            _logger.LogInformation("��ѯ�����ɹ�");

            return Ok("��ѯ�ɹ�");
        }

        // ʾ�������� ID ��ȡ�ض�����
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            // �ڴ˴���Ӵ����Է����ض���������
            return Ok();
        }

        // ʾ���������¶���
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            // �ڴ˴���Ӵ����Դ����¶���
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        // ʾ�������¶���
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order order)
        {
            // �ڴ˴���Ӵ����Ը��¶���
            return NoContent();
        }

        // ʾ����ɾ������
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            // �ڴ˴���Ӵ�����ɾ������
            return NoContent();
        }
    }
}
