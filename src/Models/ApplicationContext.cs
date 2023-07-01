using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace src.Models;

public class Network
{
    // Сеть криптовалюты

    [Key]
    public int Id { get; set; }

    [Required]
    [BindRequired]
    public string Name { get; set; }

    public List<ClientCurrency> ClientCurrencies { get; set; } = new List<ClientCurrency>();
    public List<MyCurrency> MyCurrencies { get; set; } = new List<MyCurrency>();
}

public class PaymentMethod
{   
    // Способ оплаты

    [Key]
    public int Id { get; set; }

    [BindRequired]
    public string Name { get; set; }

    public List<MyCurrency> MyCurrencies { get; set; } = new List<MyCurrency>();

    public List<ClientCurrency> ClientCurrencies { get; set; } = new List<ClientCurrency>();
}

public class ClientCurrency
{
    // Валюта, которую мы принимаем

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } // Название валюты

    [Required]
    [MaxLength(10)]
    public string ShortName { get; set; } // Короткое название валюты

    [Required]
    [MaxLength(20)]
    public string ImagePath { get; set; } // Путь к изображению

    public List<Network> Networks { get; set; } = new List<Network>(); // Сети в которых работают криптовалюты

    [Required]
    public PaymentMethod PaymentMethod { get; set; }
}

public class MyCurrency
{
    // Валюта, которую мы отдаём
    public decimal Fund { get; set; } // Наш фонд валюты. Сколько валюты мы имеем.

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } // Название валюты

    [Required]
    [MaxLength(10)]
    public string ShortName { get; set; } // Короткое название валюты

    [Required]
    [MaxLength(20)]
    public string ImagePath { get; set; } // Путь к изображению

    public List<Network> Networks { get; set; } = new List<Network>(); // Сети в которых работают криптовалюты

    [Required]
    public PaymentMethod PaymentMethod { get; set; }
}

public class MyAddresses
{
    // Адреса, на которые клиент переводит свои деньги

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(256)]
    public int Address { get; set; }

    [Required]
    public MyCurrency Currency { get; set; }

    [Required]
    public Network Network { get; set; }
}

public class OrderStatus
{
    // Статус заказа
    
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string StatusName { get; set; }
}

public class Order
{   
    // Заказ на обмен
    [Key]
    public int Id { get; set; }

    [Required]
    public uint Number { get; set; } // Номер заказа

    [Required]
    public string RandomString { get; set; } // Ссылка на заказа
    
    [Required]
    public DateTime DateTime { get; set; } // Дата и время заказа 

    [Required]
    public Decimal GiveSum { get; set; } // Сумма, которую отдаёт клиент

    [Required]
    public Decimal ReceiveSum { get; set; } // Сумма, которую получает клиент

    [MaxLength(100)]
    public string ClientName { get; set; } // Имя клиента

    [MaxLength(256)]
    [Required]
    public string ClientAddress { get; set; } // Адрес кошелька получателя

    [Required]
    public MyAddresses MyAddress { get; set; } // Адрес нашего кошелька

    [Required]
    public MyCurrency MyCurrency { get; set; } // Валюта, которую мы отдаём

    [Required]
    public ClientCurrency ClientCurrency { get; set; } // Валюта, которую отдаёт клиент

    [Required]
    public Network GiveNetwork { get; set; } // Сеть криптовалюты, которую отдаёт клиент

    [Required]
    public Network ReceiveNetwork { get; set; } // Сеть криптовалюты, которую получает клиент
}

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public Role Role { get; set; }
}

public class Role
{   
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<User> Users { get; set; }

    public Role()
    {
        Users = new List<User>();
    }
}

public class ApplicationContext : DbContext
{
    public DbSet<Network> Network { get; set; }
    public DbSet<PaymentMethod> PaymentMethod { get; set; }
    public DbSet<MyCurrency> MyCurrency { get; set; } 
    public DbSet<ClientCurrency> ClientCurreny { get; set; }
    public DbSet<MyAddresses> MyAddress { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<User> User { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }   
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}