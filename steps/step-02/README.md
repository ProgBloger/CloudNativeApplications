# Cloud Native Applications

[Previous step](../step-01/README.md) - [Next step](../step-03/README.md)

## Step 2 - Containerize a .NET Core Worker Service

1. Run `dotnet new worker -n WorkerService` in the terminal to create the .net worker project:

![creating new service](worker-service-new-screen-shot.png)

2. Open project folder in VS Code and run it:

![running service](worker-service-run-screen-shot.png)

3. Stop the worker.

4. Modify the Worker.cs file with a minor code change:

```csharp
protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    while (!stoppingToken.IsCancellationRequested)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation($"Worker Service running on: {Environment.MachineName}");
        }
        await Task.Delay(1000, stoppingToken);
    }
}
```

5. Restart the Worker Service from the console to see your machine name printed every five seconds.

6. To create a Docker container, open Visual Studio Code's Command Palette and locate the command for Docker file creation.

![docker add command](dockerfile-add-screen-shot.png)

7. Choose .NET Core Console application for Linux without Docker Compose files.

![project type selection](dockerfile-proj-type-screen-shot.png)

![container type selection](dockerfile-container-type-screen-shot.png)

![optional files selection](dockerfile-optional-screen-shot.png)

8. Right-click the Docker file and select "Build Image" to create a Docker image.

![building image of the dockerfile](dockerfile-build-image-screen-shot.png)

9. Check the Docker image in VS Code's Docker sidebar:

![docker image](dockerfile-image-screen-shot.png)

10. Test the image by right-clicking the latest tag and selecting "Run" to see it in the containers list.

![running the container](docker-image-run-screen-shot.png)

11. View container logs by right-clicking it and selecting "View Logs" to see WorkerService output in the terminal.

![view logs](docker-image-view-logs-screen-shot.png)

![container logs](docker-image-logs-screen-shot.png)

Stop the container to free system resources.

[Previous step](../step-01/README.md) - [Next step](../step-03/README.md)