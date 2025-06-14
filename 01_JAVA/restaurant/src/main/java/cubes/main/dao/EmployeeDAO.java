package cubes.main.dao;

import java.util.List;

import cubes.main.entity.Employee;

public interface EmployeeDAO {	
	
		public List<Employee> getEmployeeList();

		public void saveEmployee(Employee category);

		public Employee getEmployee(int id);

		public void deleteEmployee(int id);

}
