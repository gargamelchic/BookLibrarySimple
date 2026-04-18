using BookLibrarySimple.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrarySimple.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Books.Any())
            return;

        var authors = new List<Author>
        {
            new() { FullName = "Александр Сергеевич Пушкин" },
            new() { FullName = "Лев Николаевич Толстой" },
            new() { FullName = "Фёдор Михайлович Достоевский" },
            new() { FullName = "Михаил Афанасьевич Булгаков" },
            new() { FullName = "Антон Павлович Чехов" },
            new() { FullName = "Николай Васильевич Гоголь" },
            new() { FullName = "Иван Сергеевич Тургенев" },
            new() { FullName = "Джордж Оруэлл" },
            new() { FullName = "Джейн Остин" },
            new() { FullName = "Марк Твен" },
            new() { FullName = "Эрнест Хемингуэй" },
            new() { FullName = "Габриэль Гарсиа Маркес" },
            new() { FullName = "Джоан Роулинг" },
            new() { FullName = "Джон Р.Р. Толкин" },
            new() { FullName = "Агата Кристи" },
            new() { FullName = "Артур Конан Дойл" },
            new() { FullName = "Рэй Брэдбери" },
            new() { FullName = "Стивен Кинг" },
            new() { FullName = "Харуки Мураками" },
            new() { FullName = "Виктор Гюго" }
        };
        context.Authors.AddRange(authors);
        context.SaveChanges();

        var styles = new List<Style>
        {
            new() { Name = "Роман" },
            new() { Name = "Поэзия" },
            new() { Name = "Драма" },
            new() { Name = "Повесть" },
            new() { Name = "Рассказ" },
            new() { Name = "Фантастика" },
            new() { Name = "Детектив" },
            new() { Name = "Приключения" },
            new() { Name = "Фэнтези" },
            new() { Name = "Антиутопия" },
            new() { Name = "Классическая проза" }
        };
        context.Styles.AddRange(styles);
        context.SaveChanges();

        var publishers = new List<Publisher>
        {
            new() { Name = "Эксмо" },
            new() { Name = "АСТ" },
            new() { Name = "Азбука" },
            new() { Name = "Наука" },
            new() { Name = "Молодая гвардия" },
            new() { Name = "Иностранка" },
            new() { Name = "Corpus" },
            new() { Name = "МИФ" },
            new() { Name = "Альпина Паблишер" },
            new() { Name = "Росмэн" },
            new() { Name = "Махаон" }
        };
        context.Publishers.AddRange(publishers);
        context.SaveChanges();

        var books = new List<Book>
        {
            new() { Title = "Евгений Онегин", Year = 1833, AuthorId = authors[0].Id, StyleId = styles[1].Id, PublisherId = publishers[0].Id },
            new() { Title = "Капитанская дочка", Year = 1836, AuthorId = authors[0].Id, StyleId = styles[3].Id, PublisherId = publishers[2].Id },
            new() { Title = "Повести Белкина", Year = 1831, AuthorId = authors[0].Id, StyleId = styles[4].Id, PublisherId = publishers[1].Id },
            new() { Title = "Война и мир", Year = 1869, AuthorId = authors[1].Id, StyleId = styles[0].Id, PublisherId = publishers[1].Id },
            new() { Title = "Анна Каренина", Year = 1877, AuthorId = authors[1].Id, StyleId = styles[0].Id, PublisherId = publishers[0].Id },
            new() { Title = "Воскресение", Year = 1899, AuthorId = authors[1].Id, StyleId = styles[0].Id, PublisherId = publishers[3].Id },
            new() { Title = "Преступление и наказание", Year = 1866, AuthorId = authors[2].Id, StyleId = styles[0].Id, PublisherId = publishers[2].Id },
            new() { Title = "Идиот", Year = 1869, AuthorId = authors[2].Id, StyleId = styles[0].Id, PublisherId = publishers[1].Id },
            new() { Title = "Братья Карамазовы", Year = 1880, AuthorId = authors[2].Id, StyleId = styles[0].Id, PublisherId = publishers[0].Id },
            new() { Title = "Бесы", Year = 1872, AuthorId = authors[2].Id, StyleId = styles[0].Id, PublisherId = publishers[4].Id },
            new() { Title = "Мастер и Маргарита", Year = 1967, AuthorId = authors[3].Id, StyleId = styles[0].Id, PublisherId = publishers[5].Id },
            new() { Title = "Собачье сердце", Year = 1925, AuthorId = authors[3].Id, StyleId = styles[3].Id, PublisherId = publishers[2].Id },
            new() { Title = "Белая гвардия", Year = 1925, AuthorId = authors[3].Id, StyleId = styles[0].Id, PublisherId = publishers[0].Id },
            new() { Title = "Вишнёвый сад", Year = 1904, AuthorId = authors[4].Id, StyleId = styles[2].Id, PublisherId = publishers[4].Id },
            new() { Title = "Дама с собачкой", Year = 1899, AuthorId = authors[4].Id, StyleId = styles[4].Id, PublisherId = publishers[1].Id },
            new() { Title = "Палата №6", Year = 1892, AuthorId = authors[4].Id, StyleId = styles[3].Id, PublisherId = publishers[2].Id },
            new() { Title = "Мёртвые души", Year = 1842, AuthorId = authors[5].Id, StyleId = styles[0].Id, PublisherId = publishers[3].Id },
            new() { Title = "Ревизор", Year = 1836, AuthorId = authors[5].Id, StyleId = styles[2].Id, PublisherId = publishers[1].Id },
            new() { Title = "Шинель", Year = 1842, AuthorId = authors[5].Id, StyleId = styles[3].Id, PublisherId = publishers[0].Id },
            new() { Title = "Отцы и дети", Year = 1862, AuthorId = authors[6].Id, StyleId = styles[0].Id, PublisherId = publishers[2].Id },
            new() { Title = "Дворянское гнездо", Year = 1859, AuthorId = authors[6].Id, StyleId = styles[0].Id, PublisherId = publishers[1].Id },
            new() { Title = "1984", Year = 1949, AuthorId = authors[7].Id, StyleId = styles[9].Id, PublisherId = publishers[5].Id },
            new() { Title = "Скотный двор", Year = 1945, AuthorId = authors[7].Id, StyleId = styles[9].Id, PublisherId = publishers[6].Id },
            new() { Title = "Гордость и предубеждение", Year = 1813, AuthorId = authors[8].Id, StyleId = styles[0].Id, PublisherId = publishers[5].Id },
            new() { Title = "Приключения Тома Сойера", Year = 1876, AuthorId = authors[9].Id, StyleId = styles[7].Id, PublisherId = publishers[7].Id },
            new() { Title = "Приключения Гекльберри Финна", Year = 1884, AuthorId = authors[9].Id, StyleId = styles[7].Id, PublisherId = publishers[7].Id },
            new() { Title = "Старик и море", Year = 1952, AuthorId = authors[10].Id, StyleId = styles[3].Id, PublisherId = publishers[6].Id },
            new() { Title = "Прощай, оружие!", Year = 1929, AuthorId = authors[10].Id, StyleId = styles[0].Id, PublisherId = publishers[5].Id },
            new() { Title = "Сто лет одиночества", Year = 1967, AuthorId = authors[11].Id, StyleId = styles[0].Id, PublisherId = publishers[6].Id },
            new() { Title = "Любовь во время чумы", Year = 1985, AuthorId = authors[11].Id, StyleId = styles[0].Id, PublisherId = publishers[8].Id },
            new() { Title = "Гарри Поттер и философский камень", Year = 1997, AuthorId = authors[12].Id, StyleId = styles[8].Id, PublisherId = publishers[9].Id },
            new() { Title = "Гарри Поттер и Тайная комната", Year = 1998, AuthorId = authors[12].Id, StyleId = styles[8].Id, PublisherId = publishers[9].Id },
            new() { Title = "Хоббит, или Туда и обратно", Year = 1937, AuthorId = authors[13].Id, StyleId = styles[8].Id, PublisherId = publishers[7].Id },
            new() { Title = "Властелин колец: Братство Кольца", Year = 1954, AuthorId = authors[13].Id, StyleId = styles[8].Id, PublisherId = publishers[7].Id },
            new() { Title = "Убийство в Восточном экспрессе", Year = 1934, AuthorId = authors[14].Id, StyleId = styles[6].Id, PublisherId = publishers[0].Id },
            new() { Title = "Десять негритят", Year = 1939, AuthorId = authors[14].Id, StyleId = styles[6].Id, PublisherId = publishers[1].Id },
            new() { Title = "Собака Баскервилей", Year = 1902, AuthorId = authors[15].Id, StyleId = styles[6].Id, PublisherId = publishers[2].Id },
            new() { Title = "Этюд в багровых тонах", Year = 1887, AuthorId = authors[15].Id, StyleId = styles[6].Id, PublisherId = publishers[3].Id },
            new() { Title = "451 градус по Фаренгейту", Year = 1953, AuthorId = authors[16].Id, StyleId = styles[9].Id, PublisherId = publishers[6].Id },
            new() { Title = "Марсианские хроники", Year = 1950, AuthorId = authors[16].Id, StyleId = styles[5].Id, PublisherId = publishers[0].Id },
            new() { Title = "Сияние", Year = 1977, AuthorId = authors[17].Id, StyleId = styles[0].Id, PublisherId = publishers[1].Id },
            new() { Title = "Оно", Year = 1986, AuthorId = authors[17].Id, StyleId = styles[0].Id, PublisherId = publishers[8].Id },
            new() { Title = "Норвежский лес", Year = 1987, AuthorId = authors[18].Id, StyleId = styles[0].Id, PublisherId = publishers[10].Id },
            new() { Title = "Кафка на пляже", Year = 2002, AuthorId = authors[18].Id, StyleId = styles[0].Id, PublisherId = publishers[5].Id },
            new() { Title = "Отверженные", Year = 1862, AuthorId = authors[19].Id, StyleId = styles[0].Id, PublisherId = publishers[4].Id },
            new() { Title = "Собор Парижской Богоматери", Year = 1831, AuthorId = authors[19].Id, StyleId = styles[0].Id, PublisherId = publishers[3].Id }
        };

        context.Books.AddRange(books);
        context.SaveChanges();
    }
}