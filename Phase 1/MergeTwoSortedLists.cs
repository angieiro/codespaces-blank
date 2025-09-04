
//Definition for singly-linked list.
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public static class MergeListSolution {
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode resultListNode = new ListNode(0);
        ListNode opNode = resultListNode;
        while (list1 is not null && list2 is not null)
        {
                if (list2.val >= list1.val)
                {
                    opNode.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    opNode.next = list2;
                    list2 = list2.next;
                }
                opNode = opNode.next;
        }
        opNode.next = list1 ?? list2;
        return resultListNode.next;
        
    }
}