using Playground1.DataStructures;

namespace Playground1
{

   public class LinkedListCourt {
       public void Play() {
           var head = new ListNode();
           head.val = 1;
           head.next = new ListNode();
           head.next.val = 2;
           head.next.next = new ListNode();
           head.next.next.val = 3;
           head.next.next.next = new ListNode();
           head.next.next.next.val = 4;
           head.next.next.next.next = new ListNode();
           head.next.next.next.next.val = 5;
           var node = RemoveNthFromEnd(head, 2);
       }

       public ListNode RemoveNthFromEnd(ListNode head, int n) {
           if (head == null) return head;
           var length = GetLinkedListLength(head);
           var requiredIndex = length - n;
           var temp = head;
           var curIndex = 0;
           ListNode prev = null;
           while(curIndex != requiredIndex) {
               prev = temp;
               temp = temp.next;
               curIndex++;
           }
           if (prev == null) return head.next;
           prev.next = temp?.next;

           return head;
        }

        public ListNode ReturnNthNodeFromEnd(ListNode head, int n) {
            var temp = head;
            var count = GetLinkedListLength(head) - n;
            int index = 0;
            while(temp != null) {
                if (index == count) {
                    return temp;
                }
                index++;
                temp = temp.next;
            }
            return null;
        }

       public ListNode MiddleNode(ListNode head) {
           var temp = head;
           var count = GetLinkedListLength(head);
           
           int mid = count/2;
           int i = 0;
           while(temp != null) {
               if (i == mid) {
                   return temp;
               }
               temp = temp.next;
               i++;
           }
           return null;
        }

        public int GetLinkedListLength(ListNode head) {
            int count = 0;
            var temp = head;
            while(temp != null) {
                temp = temp.next;
                count++;
           }
            return count;
        }
   }



}