namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho sự kiện do câu lạc bộ tổ chức.
/// </summary>
public sealed class Event
{
    public Guid Id { get; private init; }
    public Guid ClubId { get; private init; }
    public string Title { get; private set; }
    public DateTime Date { get; private set; }
    public int Capacity { get; private set; }
    public bool IsOnline { get; private set; }

    private Event(
        Guid id,
        Guid clubId,
        string title,
        DateTime date,
        int capacity,
        bool isOnline)
    {
        Id = id;
        ClubId = clubId;
        Title = title;
        Date = date;
        Capacity = capacity;
        IsOnline = isOnline;
    }

    /// <summary>
    /// Tạo sự kiện với thông tin hợp lệ.
    /// </summary>
    public static Event Create(
        Guid clubId,
        string title,
        DateTime date,
        int capacity,
        bool isOnline)
    {
        if (clubId == Guid.Empty)
            throw new ArgumentException("ClubId không hợp lệ.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Tên sự kiện không được để trống.");

        if (date < DateTime.Now)
            throw new ArgumentException("Ngày sự kiện không hợp lệ.");

        if (capacity <= 0)
            throw new ArgumentException("Sức chứa phải lớn hơn 0.");

        return new Event(
            Guid.NewGuid(),
            clubId,
            title.Trim(),
            date,
            capacity,
            isOnline);
    }

    /// <summary>
    /// Kiểm tra sự kiện còn chỗ đăng ký hay không.
    /// </summary>
    public bool HasCapacity(int registeredCount)
    {
        if (registeredCount < 0)
            throw new ArgumentOutOfRangeException(
                nameof(registeredCount));

        return registeredCount < Capacity;
    }
}