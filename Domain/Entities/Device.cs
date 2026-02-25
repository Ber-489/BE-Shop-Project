namespace Domain.Entities;

public class Device
{
    public Guid Id { get; private set; }

    public Guid StoreId { get; private set; }

    public Guid BranchId { get; private set; }

    public string Name { get; private set; } = default!;

    public string SerialNumber { get; private set; } = default!;

    public string WifiSSID { get; private set; } = default!;

    public string WifiPassword { get; private set; } = default!;

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private Device() { }

    public Device(
        Guid storeId,
        Guid branchId,
        string name,
        string serialNumber,
        string wifiSSID,
        string wifiPassword)
    {
        Id = Guid.NewGuid();
        StoreId = storeId;
        BranchId = branchId;
        Name = name;
        SerialNumber = serialNumber;
        WifiSSID = wifiSSID;
        WifiPassword = wifiPassword;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}