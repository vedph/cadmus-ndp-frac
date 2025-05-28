﻿using System;
using System.IO;
using Cadmus.Core;
using Cadmus.Core.Config;
using Cadmus.NdpFrac.Parts;
using Fusi.Microsoft.Extensions.Configuration.InMemoryJson;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Hosting;

namespace Cadmus.Seed.NdpFrac.Parts.Test;

static internal class TestHelper
{
    static public Stream GetResourceStream(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return Assembly.GetExecutingAssembly().GetManifestResourceStream(
            $"Cadmus.Seed.NdpFrac.Parts.Test.Assets.{name}")!;
    }

    static public string LoadResourceText(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        using StreamReader reader = new(GetResourceStream(name),
            Encoding.UTF8);
        return reader.ReadToEnd();
    }

    private static IHost GetHost(string config)
    {
        // map
        TagAttributeToTypeMap map = new();
        map.Add(
        [
            // Cadmus.Core
            typeof(StandardItemSortKeyBuilder).Assembly,
            // Cadmus.NdpFrac.Parts
            typeof(CodFrQuireLabelsPart).Assembly
        ]);

        return new HostBuilder().ConfigureServices((hostContext, services) =>
        {
            PartSeederFactory.ConfigureServices(services,
                new StandardPartTypeProvider(map),
                // Cadmus.Seed.NdpFrac.Parts
                typeof(CodFrQuireLabelsPartSeeder).Assembly);
        })
        // extension method from Fusi library
        .AddInMemoryJson(config)
        .Build();
    }

    static public PartSeederFactory GetFactory()
    {
        return new PartSeederFactory(GetHost(LoadResourceText("SeedConfig.json")));
    }

    static public void AssertPartMetadata(IPart part)
    {
        Assert.NotNull(part.Id);
        Assert.NotNull(part.ItemId);
        Assert.NotNull(part.UserId);
        Assert.NotNull(part.CreatorId);
    }
}
