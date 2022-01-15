using System.Collections.Generic;
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
          //var node = RemoveNthFromEnd(head, 2);
          var reversedList = ReverseList(head);

        //    var list1 = new ListNode();
        //    list1.val = 1;
        //    list1.next = new ListNode();
        //    list1.next.val = 4;
        //    list1.next.next = new ListNode();
        //    list1.next.next.val = 6;

        //    var list2 = new ListNode();
        //    list2.val = 2;
        //    list2.next = new ListNode();
        //    list2.next.val = 3;
        //    list2.next.next = new ListNode();
        //    list2.next.next.val = 5;
        //    var mergedList = MergeTwoLists(list1, list2);
       }

       public ListNode ReverseList(ListNode head) {
           var stack = new Stack<int>();
           ListNode reversedHead = new ListNode(-1);
           ListNode temp = reversedHead;
           while(head != null) {
               stack.Push(head.val);
               head = head.next;
           }
           while(stack.Count > 0) {
               var cur = stack.Pop();
               temp.next = new ListNode(cur);
               temp = temp.next;
           }

           return reversedHead.next;
       }

       public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
           if(list1 == null) return list2;
           if(list2 == null) return list1;
           ListNode listToReturn = null;
           ListNode temp = null;
           while(list1 != null && list2 != null) {
               if(list1.val < list2.val) {
                   if(temp == null) {
                       //First Node
                       listToReturn = new ListNode(list1.val);
                       temp = listToReturn;
                       list1 = list1.next;
                       continue;
                   }

                   temp.next = new ListNode(list1.val);
                   temp = temp.next;
                   list1 = list1.next;
               } else {
                if(temp == null) {
                       //First Node
                       listToReturn = new ListNode(list2.val);
                       temp = listToReturn;
                        list2 = list2.next;
                       continue;
                   }
                   temp.next = new ListNode(list2.val);
                   temp = temp.next;
                   list2 = list2.next;
               }    
           }

           if(list1 == null) temp.next = list2;
           if(list2 == null) temp.next = list1;
           
           return listToReturn;
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