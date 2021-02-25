var target = Argument("target", "Deploy");
var configuration = Argument("configuration", "Release");
var solutionfolder = "./";
var outputFolder = "./artifacts";

Task("Clean")
    .Does(()=>{
        CleanDirectory(outputFolder);
    });

Task("Restore")
    .Does(()=>{
        DotNetCoreRestore(solutionfolder);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(()=>{
        DotNetCoreBuild(solutionfolder, new DotNetCoreBuildSettings{
            NoRestore = true,
            Configuration = configuration
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(()=>{
        DotNetCoreTest(solutionfolder, new DotNetCoreTestSettings{
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true
        });
    });

Task("Publish")
    .IsDependentOn("Clean")
    .IsDependentOn("Test")
    .Does(()=>{
        DotNetCorePublish(solutionfolder, new DotNetCorePublishSettings{
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true,
            OutputDirectory = outputFolder
        });
    });

Task("Deploy")
    .IsDependentOn("Publish")
    .Does(() =>
    {
        var files = GetFiles("./artifacts/*");
 
        var destination = @"./TestDeploy";
        CopyFiles(files, destination, true);
 
    });

RunTarget(target);