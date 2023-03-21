public class Toaster
{
    public SlotGroup[] slotGroups;

    public Toaster(SlotGroup[] slotGroups)
    {
        this.slotGroups = slotGroups;
    }

    public Toaster(SlotGroup slotGroup)
    {
        this.slotGroups = new SlotGroup[1];
        this.slotGroups[0] = slotGroup;
    }
}