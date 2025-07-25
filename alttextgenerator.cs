#:package OllamaSharp@5.1.19

using OllamaSharp;

// set up the client
var uri = new Uri("http://localhost:11434");
var ollama = new OllamaApiClient(uri);
ollama.SelectedModel = "gemma3";
var chat = new Chat(ollama);

// read the image file from arguments
byte[] imageBytes = File.ReadAllBytes(args[0]);
var imageBytesEnumerable = new List<IEnumerable<byte>> { imageBytes };

// generate the alt text
var message = "Generate a complete alt text description for the attached image. The description should be detailed and suitable for visually impaired users. Do not include any information about the image file name or format.";
await foreach (var answerToken in chat.SendAsync(message: message, imagesAsBytes: imageBytesEnumerable))
    Console.Write(answerToken);

// done
Console.WriteLine($">> Ollama done");