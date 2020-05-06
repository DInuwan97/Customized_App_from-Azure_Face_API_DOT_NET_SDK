using Microsoft.ProjectOxford.Face;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceAPIAzure
{
    class Program
    {
        static async Task Main(string[] args)

        {
            IFaceServiceClient faceClient = CreateFaceClient();
            var faceAttr = new[] { FaceAttributeType.Emotion, FaceAttributeType.Age, FaceAttributeType.Gender, FaceAttributeType.Glasses, FaceAttributeType.HeadPose };


            var faces = await faceClient.DetectAsync("",
                returnFaceAttributes: faceAttr);


            foreach (var face in faces)
            {

                Console.WriteLine("################ Face ###########");
                Console.WriteLine($"{face.FaceId}");
                Console.WriteLine($"Top : {face.FaceRectangle.Top}; Left : {face.FaceRectangle.Left}; Width : {face.FaceRectangle.Width}; Height : {face.FaceRectangle.Height} \n\n Face Attributes");
                Console.WriteLine($"Gender : {face.FaceAttributes.Gender} \nAge : {face.FaceAttributes.Age} \nGlasses : {face.FaceAttributes.Glasses} \n\n Emotions: ");
                Console.WriteLine($"Happiness : {face.FaceAttributes.Emotion.Happiness} Neutral : {face.FaceAttributes.Emotion.Neutral}");
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }

        static IFaceServiceClient CreateFaceClient() => new FaceServiceClient("",
            "https://<subscriptionName>cognitiveservices.azure.com/face/v1.0");
    }
}
