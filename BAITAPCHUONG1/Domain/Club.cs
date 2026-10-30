namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho câu lạc bộ sinh viên.
/// </summary>
public sealed class Club
{
    private readonly List<Member> _members = new();

    public Guid Id { get; private init; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private init; }

    public IReadOnlyList<Member> Members => _members.AsReadOnly();

    private Club(
        Guid id,
        string name,
        string description,
        DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }

    /// <summary>
    /// Tạo câu lạc bộ mới.
    /// </summary>
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên CLB không được để trống.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Mô tả CLB không được để trống.");

        return new Club(
            Guid.NewGuid(),
            name.Trim(),
            description.Trim(),
            DateTime.Now);
    }

    /// <summary>
    /// Thêm thành viên nếu chưa tồn tại trong CLB.
    /// </summary>
    public void AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(member);

        if (_members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException(
                "Thành viên đã tồn tại trong CLB.");

        _members.Add(member);
    }

    /// <summary>
    /// Trả về số lượng thành viên trong CLB.
    /// </summary>
    public int MemberCount()
    {
        return _members.Count;
    }
}