using ForestWebApp.Data;
using ForestWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace ForestWebAppUnitTests.Data;

[TestFixture]
public class ForestRepositoryTests
{
    private readonly ForestRepository _forestRepository = null!;
    private readonly ForestWebAppContext _context = null!;
    private readonly Mock<ILogger<ForestRepository>> _loggerMock = null!;

    public ForestRepositoryTests()
    {
        _context = GetMockDbContext();
        _loggerMock = new Mock<ILogger<ForestRepository>>();
        _forestRepository = new ForestRepository(_context, _loggerMock.Object);
    }


    [TearDown]
    public void TearDown()
    {
        _context.Forest.RemoveRange(_context.Forest);
        _context.SaveChanges();
    }

    /// <summary>
    ///     Prueba que el método GetForestAsync retorne el bosque correcto cuando se le pasa un id de bosque existente.
    ///     Esta es la primera clase de equivalencia de este método, los id de bosque existentes.
    ///     Usa la teoría de clases de equivalencia en I. Sommerville, Software Engineering, Global Edition. Pearson Higher Ed,
    ///     2016. (pp. 234-237)
    /// </summary>
    [Test]
    public void GetForestAsync_WithExistingForestId_ReturnsForest()
    {
        // Arrange
        var testForestIds = GetTestForestIds().ToList();
        var testForests = GetTestForests(testForestIds);
        _context.Forest.AddRange(testForests);
        _context.SaveChanges();
        var forestId = testForestIds[0];

        // Act
        var result = _forestRepository.GetForestAsync(forestId);
        var forest = result.Result;
        // Assert
        Assert.Multiple(() =>
            {
                Assert.That(forest, Is.Not.Null);
                Assert.That(forestId, Is.EqualTo(forest?.Id));
                Assert.That(forest?.Name, Is.EqualTo("Test Forest 1"));
                Assert.That(forest?.CountryOfOrigin, Is.EqualTo("Test Country 1"));
                Assert.That(forest?.TypeOfVegetation, Is.EqualTo("Test Vegetation 1"));
                Assert.That(forest?.AreaKm2, Is.EqualTo(100));
                Assert.That(forest?.OldGrowthForest, Is.EqualTo(true));
            }
        );
    }

    /// <summary>
    ///     Prueba que el método GetForestAsync retorne null cuando se le pasa un id de bosque no existente.
    ///     Esta es la segunda clase de equivalencia de este método, los id de bosque no existentes.
    ///     Usa la teoría de clases de equivalencia en I. Sommerville, Software Engineering, Global Edition. Pearson Higher Ed,
    ///     2016. (pp. 234-237)
    /// </summary>
    [Test]
    public void GetForestAsync_WithNonExistingForestId_ReturnsNull()
    {
        // Arrange
        var testForestIds = GetTestForestIds().ToList();
        var testForests = GetTestForests(testForestIds);
        _context.Forest.AddRange(testForests);
        _context.SaveChanges();
        var forestId = Guid.NewGuid();

        // Act
        var result = _forestRepository.GetForestAsync(forestId);
        var forest = result.Result;
        // Assert
        Assert.That(forest, Is.Null);
    }

    /// <summary>
    ///     Prueba que el método GetForestsAsync retorne todos los bosques existentes.
    /// </summary>
    [Test]
    public void GetForestsAsync_WithExistingForests_ReturnsForests()
    {
        // Arrange
        var testForestIds = GetTestForestIds().ToList();
        var testForests = GetTestForests(testForestIds);
        _context.Forest.AddRange(testForests);
        _context.SaveChanges();

        // Act
        var result = _forestRepository.GetForestsAsync();
        var forests = result.Result.ToList();

        forests = forests.OrderBy(f => f.AreaKm2).ToList();
        // Assert
        // NOTE: please note that assert is only one assert and it tells explicitly what
        //       was the nested assert that failed if any.
        Assert.Multiple(() =>
            {
                Assert.That(forests, Is.Not.Null);
                Assert.That(forests.Count, Is.EqualTo(3));
                for (var i = 0; i < forests.Count; i++)
                {
                    Assert.That(testForestIds[i], Is.EqualTo(forests[i].Id));
                    Assert.That($"Test Forest {i + 1}", Is.EqualTo(forests[i].Name));
                    Assert.That($"Test Country {i + 1}", Is.EqualTo(forests[i].CountryOfOrigin));
                    Assert.That($"Test Vegetation {i + 1}", Is.EqualTo(forests[i].TypeOfVegetation));
                    Assert.That((i + 1) * 100, Is.EqualTo(forests[i].AreaKm2));
                    Assert.That(i % 2 == 0, Is.EqualTo(forests[i].OldGrowthForest));
                }
            }
        );
    }

    [Test]
    public void GetForestsAsync_WithNoExistingForests_ReturnsEmptyList()
    {
        // Arrange

        // nothing to arrange here

        // Act
        var result = _forestRepository.GetForestsAsync();
        var forests = result.Result.ToList();

        // Assert
        Assert.Multiple(() =>
            {
                Assert.That(forests, Is.Not.Null);
                Assert.That(forests, Is.Empty);
            }
        );
    }

    /// <summary>
    ///     Prueba que el método GetForestsAsync retorne todos los bosques existentes ordenados por área.
    ///     Esta es la primera clase de equivalencia de este método, los bosques con datos correctos para ser agregados.
    ///     Usa la teoría de clases de equivalencia en I. Sommerville, Software Engineering, Global Edition. Pearson Higher Ed,
    ///     2016. (pp. 234-237)
    /// </summary>
    [Test]
    public void AddForestAsync_SavesForestAsExpected()
    {
        // Arrange 
        var forestGuid = Guid.NewGuid();
        var forestToAdd = GetTestForest(forestGuid);
        // Act
        var result = _forestRepository.AddForestAsync(forestToAdd);
        var forestFromDbContext = _context.Forest.First();

        // Assert
        // NOTE: please note that assert is only one assert and it tells explicitly what
        //       was the nested assert that failed if any.
        Assert.Multiple(() =>
        {
            Assert.That(result.IsCompletedSuccessfully, Is.True);
            Assert.That(forestFromDbContext, Is.EqualTo(forestToAdd));
        });
    }


    /// <summary>
    ///     Prueba que el método AddForestAsync lance una excepción cuando se le pasa un bosque con un id existente.
    ///     Esta es la segunda clase de equivalencia de este método, los bosques con ya existentes.
    ///     Usa la teoría de clases de equivalencia en I. Sommerville, Software Engineering, Global Edition. Pearson Higher Ed,
    ///     2016. (pp. 234-237)
    /// </summary>
    [Test]
    public void AddForestAsync_ThrowsArgumentException_OnExistingForest()
    {
        // Arrange
        var testForestIds = GetTestForestIds().ToList();
        var testForests = GetTestForests(testForestIds).ToList();
        _context.Forest.AddRange(testForests);
        _context.SaveChanges();

        var testForestThatExists = testForests[0];

        // Act 
        var result = _forestRepository.AddForestAsync(testForestThatExists);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsFaulted, Is.True);
            Assert.That(result.Exception?.InnerException, Is.TypeOf<ArgumentException>());
        });
    }

    /// <summary>
    ///     Prueba que el método AddForestAsync lance una excepción cuando se le pasa un bosque que es null.
    ///     Esta es la tercera clase de equivalencia de este método, los bosques que son null.
    ///     Usa la teoría de clases de equivalencia en I. Sommerville, Software Engineering, Global Edition. Pearson Higher Ed,
    ///     2016. (pp. 234-237)
    /// </summary>
    [Test]
    public void AddForestAsync_ThrowsArgumentException_OnNullForest()
    {
        // Arrange
        Forest? testForestThatIsNull = null;

        // Act 
        var result = _forestRepository.AddForestAsync(testForestThatIsNull);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsFaulted, Is.True);
            Assert.That(result.Exception?.InnerException, Is.TypeOf<InvalidOperationException>());
        });
    }

    /// <summary>
    ///     Prueba que el método UpdateForestAsync actualice el bosque existente correctamente.
    ///     Esta es la primera clase de equivalencia de este método, los bosques con datos correctos para ser actualizados.
    ///     Usa la teoría de clases de equivalencia en I. Sommerville, Software Engineering, Global Edition. Pearson Higher Ed,
    ///     2016. (pp. 234-237)
    /// </summary>
    [Test]
    public void UpdateForestAsync_UpdatesForestAsExpected()
    {
        // Arrange
        var testForestIds = GetTestForestIds().ToList();
        var testForests = GetTestForests(testForestIds).ToList();
        _context.Forest.AddRange(testForests);
        _context.SaveChanges();

        var testForestToUpdate = testForests[0];
        testForestToUpdate.Name = "Updated Forest";
        testForestToUpdate.CountryOfOrigin = "Updated Country";
        testForestToUpdate.TypeOfVegetation = "Updated Vegetation";
        testForestToUpdate.AreaKm2 = 1000;
        testForestToUpdate.OldGrowthForest = false;

        // Act 
        var result = _forestRepository.UpdateForestAsync(testForestToUpdate);
        var forestFromDbContext = _context.Forest.OrderByDescending(f => f.AreaKm2).First();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsCompletedSuccessfully, Is.True);
            Assert.That(forestFromDbContext, Is.EqualTo(testForestToUpdate));
        });
    }

    /// <summary>
    ///     Prueba que el método UpdateForestAsync lance una excepción cuando se le pasa un bosque que no existe.
    ///     Esta es la segunda clase de equivalencia, bosques que no existen.
    ///     Usa la teoría de clases de equivalencia en I. Sommerville, Software Engineering, Global Edition. Pearson Higher Ed,
    ///     2016. (pp. 234-237)
    /// </summary>
    [Test]
    public void UpdateForestAsync_ThrowsArgumentException_WhenForestDoesNotExist()
    {
        // Arrage
        var testForestIds = GetTestForestIds().ToList();
        var testForests = GetTestForests(testForestIds).ToList();
        _context.Forest.AddRange(testForests);
        _context.SaveChanges();

        var forestGuid = Guid.NewGuid();
        var forestToUpdateButFails = GetTestForest(forestGuid);

        // Act
        var result = _forestRepository.UpdateForestAsync(forestToUpdateButFails);

        Assert.Multiple(() =>
            {
                Assert.That(result.IsCompletedSuccessfully, Is.False);
                Assert.That(result.Exception?.InnerException, Is.TypeOf<ArgumentException>());
            }
        );
    }

    /// <summary>
    ///     Prueba que el método UpdateForestAsync lance una excepción cuando se le pasa un bosque que nulo.
    ///     Esta es la tercera clase de equivalencia, bosques nulos.
    ///     Usa la teoría de clases de equivalencia en I. Sommerville, Software Engineering, Global Edition. Pearson Higher Ed,
    ///     2016. (pp. 234-237)
    /// </summary>
    [Test]
    public void UpdateForestAsync_ThrowsException_WhenForestIsNull()
    {
        // Arrange
        var testForestIds = GetTestForestIds().ToList();
        var testForests = GetTestForests(testForestIds).ToList();
        _context.Forest.AddRange(testForests);
        _context.SaveChanges();
        Forest aNullForest = null;

        var result = _forestRepository.UpdateForestAsync(aNullForest);

        Assert.Multiple(() =>
        {
            Assert.That(result.Exception?.InnerException, Is.TypeOf<InvalidOperationException>());
            Assert.That(result.IsFaulted, Is.True);
        });
    }

    /// <summary>
    ///     Prueba que el método DeleteForestAsync borre el bosque existente correctamente.
    ///     Esta es la primera clase de equivalencia, bosques existentes.
    ///     Usa la teoría de clases de equivalencia en I. Sommerville, Software Engineering, Global Edition. Pearson Higher Ed,
    ///     2016. (pp. 234-237)
    /// </summary>
    [Test]
    public void DeleteForestAsync_AsExpected()
    {
        // Arrange
        var testForestIds = GetTestForestIds().ToList();
        var testForests = GetTestForests(testForestIds).ToList();
        _context.Forest.AddRange(testForests);
        _context.SaveChanges();

        var forestToDelete = testForests[0];

        // act 
        var result = _forestRepository.DeleteForestAsync(forestToDelete);
        var forestFromDbContext = _context.Forest.FirstOrDefault(f => f.Id == forestToDelete.Id);
        // Assert
        Assert.Multiple(() =>
            {
                Assert.That(result.IsFaulted, Is.False);
                Assert.That(forestFromDbContext, Is.Null);
            }
        );
    }

    /// <summary>
    ///     Prueba que el método DeleteForestAsync lance una excepción cuando se le pasa un bosque que no existe.
    ///     Esta es la segunda clase de equivalencia, bosques que no existen.
    ///     Usa la teoría de clases de equivalencia en I. Sommerville, Software Engineering, Global Edition. Pearson Higher Ed,
    ///     2016. (pp. 234-237)
    /// </summary>
    [Test]
    public void DeleteForestAsync_ThrowsException_WhenForestDoesNotExist()
    {
        // Arrange
        var testForestIds = GetTestForestIds().ToList();
        var testForests = GetTestForests(testForestIds).ToList();
        _context.Forest.AddRange(testForests);
        _context.SaveChanges();

        var forestToDelete = GetTestForest(Guid.NewGuid());

        // act 
        var result = _forestRepository.DeleteForestAsync(forestToDelete);
        var forestFromDbContext = _context.Forest.FirstOrDefault(f => f.Id == forestToDelete.Id);
        // Assert
        Assert.Multiple(() =>
            {
                Assert.That(result.IsFaulted, Is.True);
                Assert.That(result.Exception?.InnerException, Is.TypeOf<ArgumentException>());
                Assert.That(forestFromDbContext, Is.Null);
            }
        );
    }

    /// <summary>
    ///     Prueba que el método DeleteForestAsync lance una excepción cuando se le pasa un bosque que nulo.
    ///     Esta es la tercera clase de equivalencia, bosques nulos.
    /// </summary>
    [Test]
    public void DeleteForestAsync_ThrowsException_WhenForestIsNull()
    {
        // Arrange
        var testForestIds = GetTestForestIds().ToList();
        var testForests = GetTestForests(testForestIds).ToList();
        _context.Forest.AddRange(testForests);
        _context.SaveChanges();
        Forest aNullForest = null;

        // act 
        var result = _forestRepository.DeleteForestAsync(aNullForest);
        // Assert
        Assert.Multiple(() =>
            {
                Assert.That(result.IsFaulted, Is.True);
                Assert.That(result.Exception?.InnerException, Is.TypeOf<InvalidOperationException>());
            }
        );
    }

    /// <summary>
    ///     returns a list of 3 Guids for testing purposes.
    /// </summary>
    /// <returns> a list of 3 Guids </returns>
    private static IEnumerable<Guid> GetTestForestIds()
    {
        return new List<Guid>
        {
            Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()
        };
    }

    /// <summary>
    ///     As explain in the description of the microsoft.entityframeworkcore.inmemory package,
    ///     in memory database is a way to test the database without the need of a real database.
    ///     This is the in-house answer from microsoft to the problem that the db context is not recommended to be mocked.
    /// </summary>
    /// <returns> a db context fully in memory</returns>
    private static ForestWebAppContext GetMockDbContext()
    {
        var options = new DbContextOptionsBuilder<ForestWebAppContext>()
            .UseInMemoryDatabase("ForestWebApp")
            .Options;
        var dbContext = new ForestWebAppContext(options);
        return dbContext;
    }

    /// <summary>
    ///     This method is used to create a list of forest for testing purpose. It has 3 forest following the same pattern
    ///     that is "Test Forest" + a number. The number is the index of the forest in the list. The same for the other
    ///     properties.
    ///     For the Id, it is a list of Guid that is passed as a parameter. The method will use the first 3 Guids of the list.
    ///     The areas are 100, 200 and 300 km2 for the first, second and third forest respectively. Finally, the old growth
    ///     forest
    ///     the first and third forest are old growth forest.
    /// </summary>
    /// <param name="forestIds"> a list of guids </param>
    /// <returns> a list of test forests </returns>
    private static IEnumerable<Forest> GetTestForests(IEnumerable<Guid> forestIds)
    {
        var enumerable = forestIds as Guid[] ?? forestIds.ToArray();
        return new List<Forest>
        {
            new()
            {
                Id = enumerable[0], Name = "Test Forest 1",
                CountryOfOrigin = "Test Country 1",
                TypeOfVegetation = "Test Vegetation 1", AreaKm2 = 100, OldGrowthForest = true
            },
            new()
            {
                Id = enumerable[1], Name = "Test Forest 2",
                CountryOfOrigin = "Test Country 2",
                TypeOfVegetation = "Test Vegetation 2", AreaKm2 = 200, OldGrowthForest = false
            },
            new()
            {
                Id = enumerable[2], Name = "Test Forest 3",
                CountryOfOrigin = "Test Country 3",
                TypeOfVegetation = "Test Vegetation 3", AreaKm2 = 300, OldGrowthForest = true
            }
        };
    }

    /// <summary>
    ///     creates a forest for testing purposes.
    /// </summary>
    /// <param name="forestGuid"> a guid for the test forest </param>
    /// <returns>a new test forest with the given guid as id</returns>
    private static Forest GetTestForest(Guid forestGuid)
    {
        return new Forest
        {
            Id = forestGuid, Name = "Test Forest 4",
            CountryOfOrigin = "Test Country 4",
            TypeOfVegetation = "Test Vegetation 4", AreaKm2 = 400, OldGrowthForest = true
        };
    }
}