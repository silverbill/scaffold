using Xunit;

public class SimpleTests {

    public void TestingAdd(){
        Assert.Equal(10, Add(5,5));
        /*
            other Assert methods:
            Equal(a,b)
            True(a)
            False(a)
        */ 

    }

    public int Add(int x, int y){
        return x+y;
    }

}