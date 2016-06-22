
-  Moved Deposit() and Withdraw() method to the TranscaionService class, as any business logic should not be part    of the entity class

-  Coding task 1 is represented as SimpleTransfer (a class library & a test project)

-  Coding task 2 is represented as OverdraftTransfer (a class library & a test project)

-  OverdraftTransfer is derived from SimpleTransfer to override the Withdraw() method

-  Used custom exception NoAvailableFundException in case of insufficient fund

-  In my solution, transcation service is just a simple class, but it can be extended to a wcf service

-  Have tried to cover all the test cases using MSTest





