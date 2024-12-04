#pragma once
#define HYPERSPEED _declspec(dllexport)




class HyperSpeed {
public:
	//constructor
	HyperSpeed();

	//getters and setters
	float GetSpeed() const;
	void SetSpeed(float speed = 15);

private:
	float m_speed;
};