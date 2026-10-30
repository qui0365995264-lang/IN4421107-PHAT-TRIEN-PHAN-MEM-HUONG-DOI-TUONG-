namespace EduHub.Ch01.Domain;

/// <summary>
/// Trạng thái đăng ký tham dự sự kiện.
/// </summary>
public enum RegistrationStatus
{
    Pending,
    Confirmed,
    Cancelled
}

/// <summary>
/// Đại diện cho phiếu đăng ký tham dự sự kiện.
/// </summary>
public sealed class Registration
{
    public Guid Id { get; private init; }
    public Guid MemberId { get; private init; }
    public Guid EventId { get; private init; }
    public DateTime RegisteredAt { get; private init; }
    public RegistrationStatus Status { get; private set; }

    private Registration(
        Guid id,
        Guid memberId,
        Guid eventId,
        DateTime registeredAt,
        RegistrationStatus status)
    {
        Id = id;
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = registeredAt;
        Status = status;
    }

    /// <summary>
    /// Tạo phiếu đăng ký mới với trạng thái Pending.
    /// </summary>
    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty || eventId == Guid.Empty)
            throw new ArgumentException(
                "MemberId và EventId phải hợp lệ.");

        return new Registration(
            Guid.NewGuid(),
            memberId,
            eventId,
            DateTime.Now,
            RegistrationStatus.Pending);
    }

    /// <summary>
    /// Xác nhận phiếu đăng ký đang chờ xử lý.
    /// </summary>
    public void Confirm()
    {
        if (Status != RegistrationStatus.Pending)
            throw new InvalidOperationException(
                "Chỉ đăng ký Pending mới được xác nhận.");

        Status = RegistrationStatus.Confirmed;
    }

    /// <summary>
    /// Hủy phiếu đăng ký chưa bị hủy.
    /// </summary>
    public void Cancel()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InvalidOperationException(
                "Phiếu đăng ký đã bị hủy.");

        Status = RegistrationStatus.Cancelled;
    }
}