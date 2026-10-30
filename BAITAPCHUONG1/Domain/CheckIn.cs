namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho thông tin điểm danh của một đăng ký.
/// </summary>
public sealed class CheckIn
{
    public Guid Id { get; private init; }
    public Guid RegistrationId { get; private init; }
    public DateTime CheckedInAt { get; private init; }
    public string Method { get; private set; }

    private CheckIn(
        Guid id,
        Guid registrationId,
        DateTime checkedInAt,
        string method)
    {
        Id = id;
        RegistrationId = registrationId;
        CheckedInAt = checkedInAt;
        Method = method;
    }

    /// <summary>
    /// Tạo bản ghi điểm danh cho đăng ký đã xác nhận.
    /// </summary>
    public static CheckIn Create(
        Registration registration,
        string method)
    {
        ArgumentNullException.ThrowIfNull(registration);

        if (registration.Status != RegistrationStatus.Confirmed)
            throw new InvalidOperationException(
                "Chỉ đăng ký Confirmed mới được check-in.");

        if (string.IsNullOrWhiteSpace(method))
            throw new ArgumentException(
                "Phương thức check-in không được để trống.");

        return new CheckIn(
            Guid.NewGuid(),
            registration.Id,
            DateTime.Now,
            method.Trim());
    }

    /// <summary>
    /// Trả về chuỗi mô tả thông tin điểm danh.
    /// </summary>
    public string Summary()
    {
        return $"CheckIn: {Id} | Registration: {RegistrationId} | " +
               $"Thời gian: {CheckedInAt:dd/MM/yyyy HH:mm} | " +
               $"Phương thức: {Method}";
    }
}