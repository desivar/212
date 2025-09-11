using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test basic priority queue functionality with different priorities
    // Expected Result: Items should be dequeued in priority order (highest first)
    // Defect(s) Found: Loop condition bug, missing RemoveAt, priority comparison issue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        
        // Enqueue items with different priorities
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        
        // Should dequeue in priority order: High (5), Medium (3), Low (1)
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test FIFO behavior when items have the same priority
    // Expected Result: Items with same priority should be dequeued in FIFO order
    // Defect(s) Found: Using >= instead of > breaks FIFO for equal priorities
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        
        // Enqueue items with same priority
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);
        
        // Should dequeue in FIFO order when priorities are equal
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test that items are actually removed from queue
    // Expected Result: Queue should be empty after dequeuing all items
    // Defect(s) Found: Missing RemoveAt() call means items aren't actually removed
    public void TestPriorityQueue_ItemsAreRemoved()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Test", 1);
        
        // Dequeue the item
        string result = priorityQueue.Dequeue();
        Assert.AreEqual("Test", result);
        
        // Queue should now be empty and throw exception on next dequeue
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test edge case with single item
    // Expected Result: Single item should be dequeued correctly
    // Defect(s) Found: Loop condition bug could affect single item scenarios
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Only", 10);
        
        Assert.AreEqual("Only", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test highest priority item is selected when it's the last item added
    // Expected Result: Last item should be dequeued if it has highest priority
    // Defect(s) Found: Loop condition "< _queue.Count - 1" skips the last item
    public void TestPriorityQueue_HighestPriorityLast()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("Low2", 2);
        priorityQueue.Enqueue("Highest", 10); // This is the last item with highest priority
        
        // Should dequeue the last item first because it has highest priority
        Assert.AreEqual("Highest", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test empty queue throws exception
    // Expected Result: InvalidOperationException should be thrown
    // Defect(s) Found: None for this scenario
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}