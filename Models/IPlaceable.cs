namespace Model
{
    interface IPlaceable
    {
        void UpperConnect(IPlaceable placeable);
        void BottomConnect(IPlaceable placeable);
        void RightConnect(IPlaceable placeable);
        void LeftConnect(IPlaceable placeable);
    }
}