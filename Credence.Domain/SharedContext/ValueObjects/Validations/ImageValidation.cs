using Credence.Default.DomainContext.Entities.Constants.SharedContext;
using Flunt.Validations;

namespace Credence.Domain.SharedContext.ValueObjects.Validations;

public class ImageValidation : Contract<Image>
{

    public ImageValidation(Image image, string source)
    {
        Requires()
        .IsNotNullOrEmpty(image.Value, $"{source}-{ImageConst.Required}")
        .IsLowerThan(image.Value, ImageConst.ImageMax, ImageConst.ImageMaxMsg);

        if (!string.IsNullOrWhiteSpace(image.Value))
        {
            var extension = Path.GetExtension(image.Value).ToLower();

            Requires()
            .IsTrue(
                ImageConst.AllowedExtensions.Contains(extension),
                nameof(image.Value),
                $"{source}-{ImageConst.InvalidExtension}"
            );

            Requires()
            .IsTrue(
                image.Value.Contains($"{source}-{ImageConst.InvalidPathValue}"),
                nameof(image.Value),
                ImageConst.InvalidPath
            );

        }
    }
}
