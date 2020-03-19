package services;

public class ObjectWrapper<T> {
	
	private boolean status;
	private T object;
	
	
	public ObjectWrapper(T object) {
		this.object = object;
		status = true;
	}


	public T getObject() {
		return object;
	}


	public boolean isStarted() {
		return status;
	}


	public void setStatus(boolean status) {
		this.status = status;
	}

	
	
	
	
	
	
	

}
